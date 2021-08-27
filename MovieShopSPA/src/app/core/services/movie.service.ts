import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { movieCard } from 'src/app/shared/modules/movieCard';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {environment} from 'src/environments/environment';

@Injectable({   //dependency injection
  providedIn: 'root'
})
export class MovieService {
  //movie services should have all the method that deals with Movies, getTopRevenue, getTopRated
  //Use HTTPClient to make AJAX Request => use JS 
  constructor(private http: HttpClient) { }
  getTopRevenueMovies() : Observable<movieCard[]>{
  return this.http.get(`${environment.apiUrl}`+ 'Movies/toprated').pipe(
      map(resp => resp as movieCard[])
    )
  }
}
