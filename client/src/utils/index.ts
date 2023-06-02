import { NextRouter } from "next/router";

export const push = (
  router: NextRouter,
  pathname: string,
  query: {} | undefined
) => router.push({ pathname, query }, pathname);
