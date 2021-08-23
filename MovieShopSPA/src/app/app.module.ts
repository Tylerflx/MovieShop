import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { ProfileComponent } from './user/profile/profile.component';
import { FavoritesComponent } from './user/favorites/favorites.component';
import { PurchasesComponent } from './user/purchases/purchases.component';
import { TopratedComponent } from './movies/toprated/toprated.component';
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { EditprofileComponent } from './user/editprofile/editprofile.component';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';

@NgModule({ //decorator: attribute similar to C#  [Route, httpget]
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    FavoritesComponent,
    PurchasesComponent,
    TopratedComponent,
    CreateMovieComponent,
    EditprofileComponent,
    CreateCastComponent,
    MovieDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
