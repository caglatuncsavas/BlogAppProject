import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { BlogPost } from '../models/blog-post.model';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { UpdateBlogPost } from '../models/update-blog-post.model';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent implements OnInit, OnDestroy {
 id: string | null = null;
 model?: BlogPost;
 categories$?: Observable<Category[]>;
 selectedCategories?: string[];
 
 routeSubscription? : Subscription;
 updateBlogPostSubscription?: Subscription;
 getBlogPostSubscription?: Subscription;
 deleteBlogPostSubscription?: Subscription;

  constructor(
    private route : ActivatedRoute,
    private blogPostService: BlogPostService,
    private categoryService: CategoryService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories(); 

    this.routeSubscription=this.route.paramMap.subscribe({
      next: (params)=>{
        this.id = params.get('id');
        
        //Get BlogPost From API
        if(this.id){
         this.getBlogPostSubscription = this.blogPostService. getBlogPostById(this.id).subscribe({
            next: (response) =>{
              this.model = response;
              this.selectedCategories = response.categories.map(p=> p.id);//Get the id of the categories
            }
          });
        }
      }
    });
  }

  //onFormSubmit method which talks to the service, API to update the blog post
  onFormSubmit(): void {
    //Convert this model to request Object
    if(this.model && this .id){
      var updateBlogPost : UpdateBlogPost = {
        author: this.model.author,
        categories: this.selectedCategories ?? [],
        content: this.model.content,
        coverImageUrl: this.model.coverImageUrl,
        isVisible: this.model.isVisible,
        publishedDate: this.model.publishedDate,
        shortDescription: this.model.shortDescription,
        title: this.model.title,
        urlHandle: this.model.urlHandle
    };
    this.updateBlogPostSubscription = this.blogPostService.updateBlogPost(this.id, updateBlogPost)
    .subscribe({
      next: (response)=>{
        this.router.navigateByUrl('/admin/blogposts');
      }
    });
   }
  }

  onDelete(): void{
    if(this.id){
      //Call the service to delete the blog post
     this.deleteBlogPostSubscription= this.blogPostService.deleteBlogPost(this.id)
      .subscribe({
        next: (response)=>{
          this.router.navigateByUrl('/admin/blogposts');
        }
      })
    }
  }

  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
    this.updateBlogPostSubscription?.unsubscribe();
    this.getBlogPostSubscription?.unsubscribe();
    this.deleteBlogPostSubscription?.unsubscribe();
  }
}
