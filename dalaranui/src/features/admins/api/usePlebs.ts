import { useState } from 'react';
import { axios } from '@/lib/axios';

export type PlebDecision = {
  plebId: string;
  isAccepted: boolean;
};

export type PlebRequestResponse = {
  plebId: string;
  isAccepted: boolean;
  registrationRequest: {
    occurredAt: string;
    requestedUsername: string;
    requestedPassword: string;
    requestMessage: string;
  };
};

export const usePlebs = () => {
  const [isLoading, setIsLoading] = useState(false);

  const getPlebRequests = async (): Promise<PlebRequestResponse[]> => {
    setIsLoading(true);
    try {
      const response = await axios.get('/admin/plebs');
      if (isValidPlebRequestArray(response)) {
        return Promise.resolve(response);
      } else {
        return Promise.reject('Unexpected format returned from api');
      }
    } catch (err) {
      console.error(err);
      return Promise.reject(err);
    } finally {
      setIsLoading(false);
    }
  };

  const makePlebsDecisions = async (plebsDecisions: PlebDecision[]): Promise<string> => {
    setIsLoading(true);
    try {
      await axios.post('/admin/plebs/decision', plebsDecisions);
      return "Plebs decisions successfully settled";
    } catch (error) {
      if (typeof error === 'string') {
        return error;
      }
      return Promise.reject(error);
    } finally {
      setIsLoading(false);
    }
  };

  return {
    isLoading,
    getPlebRequests,
    makePlebsDecisions,
  };
};

const isValidPlebRequestArray = (
  object: unknown
): object is Array<PlebRequestResponse> => {
  if (Array.isArray(object)) {
    return object.every((obj) => isValidPlebRequest(obj));
  }
  return false;
};

const isValidPlebRequest = (object: unknown): object is PlebRequestResponse => {
  if (object !== null && typeof object === 'object') {
    return 'plebId' in object;
  }
  return false;
};