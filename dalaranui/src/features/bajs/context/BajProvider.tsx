import { createContext, useState } from 'react';
import { BajContextType, BajStateType } from '@/features/bajs/types';

export const BajContext = createContext<BajContextType | null>(null);
const defaultBajState: BajStateType = {
  bajId: '',
  bajPicture: '',
  bajProfileName: '',
};

type Props = {
  children: React.ReactNode;
};
export const BajProvider: React.FC<Props> = ({ children }) => {
  const [bajState, setBajState] = useState<BajStateType>(defaultBajState);

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
