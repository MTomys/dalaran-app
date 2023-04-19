import React, { useEffect, useState } from 'react';
import PlebRequest, { PlebRequestProps } from './PlebRequest';
import usePlebs from '../../api/plebs/usePlebs';

const PlebRequests: React.FC = () => {
  const [plebRequests, setPlebRquests] = useState<PlebRequestProps[]>([]);
  const { isLoading, getPlebRequests, acceptPleb, rejectPleb } = usePlebs();

  useEffect(() => {
    loadPlebs();
  }, []);

  const loadPlebs = async () => {
    const data = await getPlebRequests();
    setPlebRquests(data);
  };

  const handlePlebAccept = async (plebId: string) => {
    await acceptPleb(plebId);
  };

  const handlePlebReject = async (plebId: string) => {
    await rejectPleb(plebId);
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
    </>
  );
};

export default PlebRequests;
