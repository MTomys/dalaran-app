import { useEffect, useState } from 'react';
import {
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel,
} from '@microsoft/signalr';
import { ReceiveChatMessageParams, SendChatMessageParams } from '../types';

const HUB_URL = '/api/hubs/chat';

type ChatMessagingParams = {
  authToken: string;
  onChatMessageReceive:
    | null
    | ((ReceiveChatMessageParams: ReceiveChatMessageParams) => void);
};

export const useChatMessaging = (params: ChatMessagingParams) => {
  const [connection, setConnection] = useState<HubConnection | null>(null);

  useEffect(() => {
    createConnection();
  }, []);

  const createConnection = () => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(HUB_URL, { accessTokenFactory: () => params.authToken })
      .configureLogging(LogLevel.Trace)
      .withAutomaticReconnect()
      .build();
    setConnection(newConnection);
  };

  useEffect(() => {
    if (connection && connection.state === HubConnectionState.Disconnected) {
      connect(connection);
    }
    return () => {
      if (connection && connection.state === HubConnectionState.Connected) {
        disconnect(connection);
      }
    };
  }, [connection]);

  const connect = async (connection: HubConnection) => {
    await connection
      .start()
      .then(() => {
        connection?.on('ReceiveMessage', receiveMessage);
      })
      .catch((err) => {
        console.log('error found: ', err);
      });
  };

  const receiveMessage = (receiveMessageParams: ReceiveChatMessageParams) => {
    console.log('receiving message: ', receiveMessageParams);
    if (params.onChatMessageReceive) {
      params.onChatMessageReceive(receiveMessageParams);
    }
  };

  const disconnect = async (connection: HubConnection) => {
    await connection.stop();
  };

  const sendMessage = async (sendMessageParams: SendChatMessageParams) => {
    await connection?.invoke('SendMessage', sendMessageParams);
  };

  return { sendMessage };
};
