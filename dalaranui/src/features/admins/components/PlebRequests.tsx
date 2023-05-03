import React, { useEffect, useState } from 'react';
import {
  PlebRequest,
  PlebRequestResponse,
  usePlebs,
} from '@/features/admins';

export const PlebRequests: React.FC = () => {
  const [plebRequests, setPlebRequests]
      = useState<PlebRequestResponse[]>([]);
  const { isLoading, getPlebRequests, makePlebsDecisions } = usePlebs();
  const [decisionStatus, setDecisionStatus] = useState('');

  useEffect(() => {
    loadPlebs();
  }, []);

  const loadPlebs = async () => {
    const data = await getPlebRequests();
    setPlebRequests(data);
  };

  const handlePlebAccept = async (plebId: string) => {
    setPlebRequests((current) =>
      current.map((p) => (p.plebId === plebId ? { ...p, isAccepted: true } : p))
    );
  };

  const handlePlebReject = async (plebId: string) => {
    setPlebRequests((current) =>
      current.map((p) =>
        p.plebId === plebId ? { ...p, isAccepted: false } : p
      )
    );
  };

  const handleMakeDecisions = async () => {
    console.log(plebRequests);

    const plebsDecisions = plebRequests.map((pr) => ({
      plebId: pr.plebId,
      isAccepted: pr.isAccepted,
    }));

    const decisionStatus = await makePlebsDecisions(plebsDecisions);
    setDecisionStatus(decisionStatus);
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
      {isLoading && <p>Data is currently loading</p>}
      {!isLoading && plebRequests.length === 0 && (
        <p>The pleb request list is empty!</p>
      )}
      <ol>{plebRequestItems}</ol>
      <button onClick={handleMakeDecisions}>Send decisions</button>
      <p>{decisionStatus}</p>
    </>
  );
};
