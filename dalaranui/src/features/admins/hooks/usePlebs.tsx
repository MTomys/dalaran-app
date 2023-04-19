import { useState } from 'react';
import useAxiosPrivate from '../../hooks/api/useAxiosPrivate';
import { PlebRequestProps } from '../../components/Admin/PlebRequest';

const usePlebs = () => {
  const axiosPrivate = useAxiosPrivate();
  const [isLoading, setIsLoading] = useState(false);

  const getPlebRequests = async (): Promise<PlebRequestProps[]> => {
    setIsLoading(true);
    try {
      const response = await axiosPrivate.get('/admin/plebs');
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

  const acceptPleb = async (plebId: string): Promise<PlebRequestProps> => {
    const result = await makePlebDecision(plebId, true);
    return result;
  };

  const rejectPleb = async (plebId: string): Promise<PlebRequestProps> => {
    const result = await makePlebDecision(plebId, false);
    return result;
  };

  const makePlebDecision = async (
    plebId: string,
    isAccepted: boolean
  ): Promise<PlebRequestProps> => {
    setIsLoading(true);

    const payload = JSON.stringify({
      plebId: plebId,
      isAccepted: isAccepted,
    });

    try {
      const response = await axiosPrivate.post(
        '/admin/plebs/decision',
        payload
      );
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

export default usePlebs;

const isValidPlebRequestArray = (
  object: unknown
): object is Array<PlebRequestProps> => {
  if (Array.isArray(object)) {
    return object.every((obj) => isValidPlebRequest(obj));
  }
  return false;
};

const isValidPlebRequest = (object: unknown): object is PlebRequestProps => {
  if (object !== null && typeof object === 'object') {
    return 'plebId' in object;
  }
  return false;
};
