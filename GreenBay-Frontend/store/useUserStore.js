import { create } from "zustand";

export const useUserStore = create((set) => ({
  balance: 0,
  updateBalance: async (newBalance) => set({ balance: newBalance })
}));
