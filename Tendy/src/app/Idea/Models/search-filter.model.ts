import { SearchFilter } from "../../common/models";

export interface SearchFilter extends SearchFilter {
    isUserAuthor: boolean;

    categories: number[];
}