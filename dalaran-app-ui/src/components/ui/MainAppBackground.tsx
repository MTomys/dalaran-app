import React from 'react';
import styles from './MainAppBackground.module.css';

type Props = {
  children: React.ReactNode;
};

const MainAppBackground = ({ children }: Props) => {
  return <div className={styles.mainbackground}>{children}</div>;
};
