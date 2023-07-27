import React from 'react';
import { BajPanel, BajProvider, useGetBajMe } from '@/features/bajs';

export const BajPage: React.FC = () => {
  const bajMeQuery = useGetBajMe();

  if (bajMeQuery.isLoading) {
    return <div>Loading baj page...</div>;
  }

  if (bajMeQuery.isError) {
    return <pre className="w-32">{JSON.stringify(bajMeQuery.error)}</pre>;
  }

  const bajProviderInitialState = {
    bajId: bajMeQuery.data.id,
    bajProfileName: bajMeQuery.data.profileName,
    bajPicture: bajMeQuery.data.profilePicture,
  };

  return (
    <main>
      <BajProvider startingState={bajProviderInitialState}>
        <BajPanel />
      </BajProvider>
    </main>
  );
};
