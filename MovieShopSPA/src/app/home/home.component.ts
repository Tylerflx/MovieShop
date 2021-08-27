import { movieCard } from 'src/app/shared/modules/movieCard';
import { MovieService } from './../core/services/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movies !:movieCard[];

  constructor(private MovieService: MovieService) { }

  ngOnInit(): void {
    //right event to call api 
    this.MovieService.getTopRevenueMovies().subscribe(
      m => {
        this.movies = m;
        console.log('inside home component init method');
        console.table(this.movies);
      }
    );
  }
  //Angular Life Cycle
}
