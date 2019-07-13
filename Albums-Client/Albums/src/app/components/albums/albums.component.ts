import { Component, OnInit } from '@angular/core';
import { AlbumsService } from '../../services/albums.service';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {
  albums: any[];
  selectedAlbum: number;
  currentAlbum = 0;
  constructor(private albumsSvc: AlbumsService) {}

  ngOnInit() {
    this.getAlbums();
  }

  getAlbums() {
    this.albumsSvc.getAlbums().subscribe(res => (this.albums = res));
  }
}
