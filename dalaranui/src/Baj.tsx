import React from 'react';

export type BajProps = {
  username: string;
  isActive: boolean;
  lastActive: Date;
};

const Baj: React.FC<BajProps> = (props) => {
  const { username, isActive, lastActive } = props;

  return (
    <div>
      <span>{isActive}</span>
      <span>{lastActive.toISOString()}</span>
      <span>{username}</span>
    </div>
  );
};

export default Baj;
