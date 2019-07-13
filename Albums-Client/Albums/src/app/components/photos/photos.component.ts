import { Component, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import { AlbumsService } from 'src/app/services/albums.service';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit, OnChanges {
  @Input() selectedAlbum: number;
  photos: any[];
  selectedPhoto = 0;

  constructor(private albumsSvc: AlbumsService) {}

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    this.selectedPhoto = 0;
    this.getPhotos();
  }

  getPhotos() {
    this.photos = [];
    if (this.selectedAlbum) {
      this.albumsSvc
        .getPhotos(this.selectedAlbum)
        .subscribe(res => (this.photos = res));
    }
  }
}
