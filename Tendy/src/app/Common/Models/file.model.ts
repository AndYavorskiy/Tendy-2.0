export class FileModel extends File {
    id: number;

    ideaId: number;

    name: string;

    extension: string;

    sourceUrl: string;

    source: string;

    isPrivate: boolean;

    dateOfCreation: Date;
}