import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  
 categories$?: Observable<Category[]>;
 totalCount? :number;

 pageNumber = 1;
  pageSize = 2;

  constructor(private categoryService: CategoryService ){}
  
  ngOnInit(): void {

    this.categoryService.getCategoryCount()
    .subscribe({
      next:(value)=>{
       this.totalCount = value;

       this. categories$ = this.categoryService.getAllCategories(
        undefined,
        undefined,
        undefined,
        this.pageNumber,
        this.pageSize
       );
      }
    })
  }

  onSearch(query: string){
    this.categories$ = this.categoryService.getAllCategories(query);
  }

  sort(sortBy: string, sortDirection: string){
this.categories$ = this.categoryService.getAllCategories(undefined, sortBy, sortDirection);
  }
}
