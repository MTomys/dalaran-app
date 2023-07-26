export type BajContactResponse = {
  image: string;
  profileName: string;
  contactId: string;
};

export type BajContextType = {
  bajState: BajStateType;
  updateBajPicture: (pictureUrl: string) => void;
  updateBajId: (bajId: string) => void;
  updateBajProfileName: (bajProfileName: string) => void;
};

export type BajStateType = {
  bajPicture: string;
  bajId: string;
  bajProfileName: string;
};
