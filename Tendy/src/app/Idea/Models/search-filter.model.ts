import { SearchFilter } from "../../Common/Models";

export interface SearchFilter extends SearchFilter {
    isUserAuthor: boolean;
    categories: number[];
}