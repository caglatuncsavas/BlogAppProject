export interface BlogPost{
    id: string;
    title: string;
    shortDescription: string;
    content: string;
    coverImageUrl: string;
    urlHandle: string;
    author: string;
    publishedDate: Date;
    isVisible: boolean;
}