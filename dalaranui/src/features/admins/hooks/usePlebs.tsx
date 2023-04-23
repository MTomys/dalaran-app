import { useState } from 'react';
import { axios } from '@/lib/axios';

export type PlebRequestResponse = {
  plebId: string;
  registrationRequest: {
    occuredAt: string;
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
      const data = response.data;

      if (isValidPlebRequestArray(data)) {
        return Promise.resolve(data);
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

  const acceptPleb = async (plebId: string): Promise<PlebRequestResponse> => {
    const result = await makePlebDecision(plebId, true);
    return result;
  };

  const rejectPleb = async (plebId: string): Promise<PlebRequestResponse> => {
    const result = await makePlebDecision(plebId, false);
    return result;
  };

  const makePlebDecision = async (
    plebId: string,
    isAccepted: boolean
  ): Promise<PlebRequestResponse> => {
    setIsLoading(true);

    const payload = JSON.stringify({
      plebId: plebId,
      isAccepted: isAccepted,
    });

    try {
      const response = await axios.post('/admin/plebs/decision', payload);
      const data = response.data;

      if (isValidPlebRequest(data)) {
        return Promise.resolve(data);
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

  return { isLoading, getPlebRequests, acceptPleb, rejectPleb };
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
