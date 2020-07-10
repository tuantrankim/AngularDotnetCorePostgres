import { BrowserModule, Title, Meta } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CreatePostComponent } from './create-post/create-post.component';
import { NgbTypeaheadModule, NgbTooltipModule} from '@ng-bootstrap/ng-bootstrap';
import { SearchCityComponent } from './search-city/search-city.component';
import { SearchCategoryComponent } from './search-category/search-category.component';
import { SearchContentComponent } from './search-content/search-content.component';
import { PostListComponent } from './post-list/post-list.component';
import { SearchComponent } from './search/search.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { PostDetailComponent } from './post-detail/post-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PostListComponent,
    CreatePostComponent,
    SearchCityComponent,
    SearchCategoryComponent,
    SearchContentComponent,
    SearchComponent,
    CategoryListComponent,
    PostDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    NgbTypeaheadModule,
    NgbTooltipModule,
    RouterModule.forRoot([
      { path: '', component: PostListComponent, pathMatch: 'full', data: { kind: 'search' } },
      { path: 'category/:categoryId/:categoryDescription', component: PostListComponent, data: { kind: 'category' } },
      { path: 'post/:postId/:postTitle', component: PostListComponent, data: { kind: 'post' } },
      { path: 'create-post', component: CreatePostComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    Title,
    Meta,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
