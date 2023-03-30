import React, { useState } from 'react';
import PlebRequest, { PlebRequestType } from './PlebRequest';

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
  const plebRequestItems = plebRequests.map((plebRequest) => (
    <PlebRequest {...plebRequest} />
  ));

  return <ol>{plebRequestItems}</ol>;
};

export default PlebRequests;
