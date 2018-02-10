export class FileModel extends File {
    public id: number;

    public attachmentId: number;

    public name: string;

    public extension: string;

    public sourceUrl: string;

    public source: string;

    public isPrivate: boolean;

    public dateOfCreation: Date;
}