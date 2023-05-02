import { useState } from 'react';
import { axios } from '@/lib/axios';

export type PlebsDecisionsRequests = {
  decisionsRequest: PlebDecision[];
};

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
        throw new Error(
          'Unexpected format returned from API when getting pleb requests'
        );
      }
    } catch (err) {
      console.error(err);
      return Promise.reject(err);
    } finally {
      setIsLoading(false);
    }
  };

  const makePlebsDecisions = async (
    plebsDecisions: PlebsDecisionsRequests
  ): Promise<PlebRequestResponse> => {
    setIsLoading(true);

    const payload = JSON.stringify(plebsDecisions);

    try {
      const response = await axios.post('/admin/plebs/decision', payload);

      if (isValidPlebRequest(response)) {
        return Promise.resolve(response);
      } else {
        throw new Error(
          'Unexpected format returned from API when posting pleb decision'
        );
      }
    } catch (err) {
      console.error(err);
      return Promise.reject(err);
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
