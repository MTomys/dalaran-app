import React from 'react';

type Props = {
  username: string;
  isActive: boolean;
};

const BajsList: React.FC<Props> = (props) => {
  const { username, isActive } = props;

  return (
    <div>
      <span>{isActive}</span>
      <span>{username}</span>
    </div>
  );
};

export default BajsList;
