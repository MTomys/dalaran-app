import React from 'react';

type Props = {
  children: React.ReactNode;
};

const MainBackground: React.FC<Props> = (props) => {
  const { children } = props;
  return <div>{children}</div>;
};

export default MainBackground;
