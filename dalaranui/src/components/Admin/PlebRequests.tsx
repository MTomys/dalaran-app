import React, { useEffect, useState } from 'react';
import PlebRequest, { PlebRequestType } from './PlebRequest';
import useAxiosPrivate from '../../hooks/api/useAxiosPrivate';

const mockData: PlebRequestType[] = [
  {
    plebId: '123',
    registrationRequest: {
      occuredAt: '30-03-2023',
      requestedUsername: 'username',
      requestedPassword: 'password',
      requestMessage: 'plz accept',
    },
    isAccepted: false,
  },
];

const PlebRequests: React.FC = () => {
  const [plebRequests, setPlebRequests] = useState<PlebRequestType[]>(mockData);
  const axiosPrivate = useAxiosPrivate();
  const plebRequestItems = plebRequests.map((plebRequest) => (
    <PlebRequest {...plebRequest} />
  ));

  const getPlebRequests = async () => {
    try {
      const response = await axiosPrivate.get('/admin/plebs');
      const data = response.data;
      if (isValidPlebRequestArray(data)) {
        console.log('this response data is a valid pleb array');
        setPlebRequests(data);
      }
    } catch (err) {
      console.error(err);
    }
  };

  useEffect(() => {
    getPlebRequests();
  }, []);

  return <ol>{plebRequestItems}</ol>;
};

const isValidPlebRequestArray = (
  object: unknown
): object is Array<PlebRequestType> => {
  if (Array.isArray(object)) {
    return object.every((obj) => isValidPlebRequest(obj));
  }
  return false;
};

const isValidPlebRequest = (object: unknown): object is PlebRequestType => {
  if (object !== null && typeof object === 'object') {
    return 'plebId' in object;
  }
  return false;
};

export default PlebRequests;
