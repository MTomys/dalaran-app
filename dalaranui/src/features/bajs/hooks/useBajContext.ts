import { useContext } from 'react';
import { BajContext } from '@/features/bajs';

export const useBajContext = () => {
  const context = useContext(BajContext);
  if (!context) {
    throw new Error('baj context should not be null when calling this method');
  }
  return context;
};
