export interface AddBlogPost{
    title: string;
    shortDescription: string;
    content: string;
    coverImageUrl: string;
    urlHandle: string;
    author: string;
    publishedDate: Date;
    isVisible: boolean;
    categories: string[];
}