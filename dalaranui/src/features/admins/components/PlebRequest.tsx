import React from 'react';

export type RegistrationRequest = {
  occuredAt: string;
  requestedUsername: string;
  requestedPassword: string;
  requestMessage: string;
};

export type PlebRequestProps = {
  plebId: string;
  registrationRequest: RegistrationRequest;
  isAccepted: boolean;
  onAcceptPlebRequest: (plebId: string) => void;
  onRejectPlebRequest: (plebId: string) => void;
};

export const PlebRequest: React.FC<PlebRequestProps> = (props) => {
  const {
    plebId,
    registrationRequest,
    isAccepted,
    onAcceptPlebRequest,
    onRejectPlebRequest,
  } = props;

  const acceptClickedHandler = () => {
    onAcceptPlebRequest(plebId);
  };
  const rejectClickedHandler = () => {
    onRejectPlebRequest(plebId);
  };

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
        <div>
          <button onClick={acceptClickedHandler}>Accept</button>
          <button onClick={rejectClickedHandler}>Reject</button>
        </div>
      </div>
      <div>{isAccepted ? 'yes' : 'no'}</div>
    </li>
  );
};
