import { axios } from '@/lib/axios';
import { useMutation, useQuery } from '@tanstack/react-query';

export type PlebDecision = {
  plebId: string;
  isAccepted: boolean;
};

export type PlebRequestResponse = {
  plebId: string;
  isAccepted: boolean;
  registrationRequest: {
    occurredAt: string;
    requestedUsername: string;
    requestedPassword: string;
    requestMessage: string;
  };
};

const getPlebRequests = async (): Promise<PlebRequestResponse[]> => {
  return (await axios.get<PlebRequestResponse[]>('/admin/plebs')).data;
};

const makePlebsDecisions = async (plebsDecisions: PlebDecision[]): Promise<void> => {
  await axios.post('/admin/plebs/decision', plebsDecisions);
};

export const useGetPlebsQuery = () => {
  return useQuery({
    queryKey: ['plebs'],
    queryFn: () => getPlebRequests,
  });
};

export const useMakePlebsDecisionMutation = () => {
  return useMutation({
    mutationFn: (params: PlebDecision[]) => makePlebsDecisions(params),
  });
};
