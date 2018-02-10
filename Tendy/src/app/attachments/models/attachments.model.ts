import { LinkModel, FileModel } from "./index";

export class Attachments {
    public id: number;

    public Links: LinkModel[] = [];

    public Files: FileModel[] = [];
}