import { City } from "./City";

export interface PostSearchCriteria
{
  fromPostId: number;
  titleContain: string;
  cityId: number;
  categoryId: number;
}

