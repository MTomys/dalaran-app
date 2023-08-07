import { useEffect, useState } from 'react';
import {
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel,
} from '@microsoft/signalr';
import { SendChatMessageParams } from '../types';

const HUB_URL = '/api/hubs/chat';

type ChatMessagingParams = {
  authToken: string;
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

  type ReceiveMessageParams = {
    sender: string;
    recipient: string;
    content: string;
  };

  const receiveMessage = (params: ReceiveMessageParams) => {
    console.log(
      `received mesage: from ${params.sender} to ${params.recipient} content: ${params.content}`
    );
  };

  const disconnect = async (connection: HubConnection) => {
    await connection.stop();
  };

  const checkConnectionState = () => {
    if (connection) {
      console.log('connection state => ', connection.state);
    }
  };

  const sendMessage = async (params: SendChatMessageParams) => {
    await connection?.invoke('SendMessage', params);
  };

  return { checkConnectionState, sendMessage };
};
