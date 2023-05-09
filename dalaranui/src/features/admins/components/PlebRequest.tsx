import React from 'react';

type RegistrationRequest = {
  occurredAt: string;
  requestedUsername: string;
  requestedPassword: string;
  requestMessage: string;
};

type Props = {
  plebId: string;
  registrationRequest: RegistrationRequest;
  isAccepted: boolean;
  onAcceptPlebRequest: (plebId: string) => void;
  onRejectPlebRequest: (plebId: string) => void;
};

export const PlebRequest: React.FC<Props> = (props) => {
  const {
    plebId,
    registrationRequest,
    isAccepted = false,
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
    <li id={plebId}>
      <div>{plebId}</div>
      <div>
        <div>start</div>
        <div>{registrationRequest.occurredAt}</div>
        <div>{registrationRequest.requestedUsername}</div>
        <div>{registrationRequest.requestedPassword}</div>
        <div>{registrationRequest.requestMessage}</div>
        <div>
          <button onClick={acceptClickedHandler}>Accept</button>
          <button onClick={rejectClickedHandler}>Reject</button>
        </div>
      </div>
      <div>{isAccepted ? 'yes' : 'no'}</div>
    </li>
  );
};
