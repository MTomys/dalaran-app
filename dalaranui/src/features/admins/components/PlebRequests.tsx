import React, { useState } from 'react';
import {
  PlebRequest,
  PlebRequestResponse,
  useMakePlebsDecision,
} from '@/features/admins';

type Props = {
  requests: PlebRequestResponse[];
};

export const PlebRequests: React.FC<Props> = (props) => {
  const { requests } = props;
  const [plebRequests, setPlebRequests] = useState<PlebRequestResponse[]>(requests);

  const makePlebDecisionMutation = useMakePlebsDecision();

  const handlePlebAccept = async (plebId: string) => {
    setPlebRequests((current) =>
      current.map((p) => (p.plebId === plebId ? { ...p, isAccepted: true } : p))
    );
  };

  const handlePlebReject = async (plebId: string) => {
    setPlebRequests((current) =>
      current.map((p) => (p.plebId === plebId ? { ...p, isAccepted: false } : p))
    );
  };

  const handleMakeDecisions = async () => {
    const plebsDecisions = plebRequests.map((pr) => ({
      plebId: pr.plebId,
      isAccepted: pr.isAccepted,
    }));

    makePlebDecisionMutation.mutate(plebsDecisions);
  };

  const plebRequestItems = plebRequests.map((plebRequest) => (
    <PlebRequest
      {...plebRequest}
      onAcceptPlebRequest={handlePlebAccept}
      onRejectPlebRequest={handlePlebReject}
    />
  ));

  return (
    <>
      {plebRequests.length === 0 && <p>The pleb request list is empty!</p>}
      <ol>{plebRequestItems}</ol>
      <button onClick={handleMakeDecisions}>Send decisions</button>
    </>
  );
};
