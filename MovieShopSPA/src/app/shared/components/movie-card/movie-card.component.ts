import { movieCard } from 'src/app/shared/modules/movieCard';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie!:movieCard;

  constructor() { }

  ngOnInit(): void {
  }

}
