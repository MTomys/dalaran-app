import { axios } from '@/lib/axios';
import { useMutation } from '@tanstack/react-query';

export type PlebDecision = {
  plebId: string;
  isAccepted: boolean;
};

const makePlebsDecisions = async (plebsDecisions: PlebDecision[]): Promise<void> => {
  await axios.post('/admin/plebs/decision', plebsDecisions);
};

export const useMakePlebsDecision = () => {
  return useMutation({
    mutationFn: (params: PlebDecision[]) => makePlebsDecisions(params),
  });
};
