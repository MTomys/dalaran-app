import React from 'react';

type RegistrationRequest = {
  occuredAt: string;
  requestedUsername: string;
  requestedPassword: string;
  requestMessage: string;
};

export type PlebRequestType = {
  plebId: string;
  registrationRequest: RegistrationRequest;
  isAccepted: boolean;
};

const PlebRequest: React.FC<PlebRequest> = (props) => {
  const { plebId, registrationRequest, isAccepted } = props;

  return (
    <li>
      <div>{plebId}</div>
      <div>
        <div>start</div>
        <div>{registrationRequest.occuredAt}</div>
        <div>{registrationRequest.requestedUsername}</div>
        <div>{registrationRequest.requestedPassword}</div>
        <div>{registrationRequest.requestMessage}</div>
        <div>end</div>
      </div>
      <div>{isAccepted ? 'yes' : 'no'}</div>
    </li>
  );
};

export default PlebRequest;
