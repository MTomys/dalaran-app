import { createContext, useState } from 'react';
import { BajContextType, BajStateType } from '@/features/bajs/types';

export const BajContext = createContext<BajContextType | null>(null);
type Props = {
  startingState: BajStateType;
  children: React.ReactNode;
};
export const BajProvider: React.FC<Props> = (props) => {
  const { startingState, children } = props;
  const [bajState, setBajState] = useState<BajStateType>(startingState);

  const updateBajPicture = (pictureUrl: string) => {
    setBajState((prev) => ({ ...prev, bajPicture: pictureUrl }));
  };
  const updateBajId = (bajId: string) => {
    setBajState((prev) => ({ ...prev, bajId }));
  };
  const updateBajProfileName = (bajProfileName: string) => {
    setBajState((prev) => ({ ...prev, bajProfileName }));
  };

  return (
    <BajContext.Provider
      value={{ updateBajPicture, updateBajId, updateBajProfileName, bajState }}
    >
      {children}
    </BajContext.Provider>
  );
};
