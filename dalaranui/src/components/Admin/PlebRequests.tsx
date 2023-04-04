import React, { useEffect, useState } from 'react';
import PlebRequest, { PlebRequestType } from './PlebRequest';
import useAxiosPrivate from '../../hooks/api/useAxiosPrivate';

const mockData: PlebRequestType[] = [
  {
    plebId: '123',
    registrationRequest: {
      requestedPassword: 'password',
      requestedUsername: 'username',
      requestMessage: 'plz accept',
      occuredAt: '30-03-2023',
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
      console.log(response);
    } catch (err) {
      console.error(err);
    }
  };

  useEffect(() => {
    getPlebRequests();
  }, []);

  return <ol>{plebRequestItems}</ol>;
};

export default PlebRequests;
