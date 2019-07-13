import { Component, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import { AlbumsService } from 'src/app/services/albums.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit, OnChanges {
  @Input() selectedAlbum = 0;
  @Input() selectedPhoto = 0;
  comments: any[];

  constructor(private albumsSvc: AlbumsService) {}

  ngOnInit() {}

  ngOnChanges(changes: SimpleChanges): void {
    this.comments = [];
    this.getComments();
  }

  getComments() {
        if (this.selectedPhoto !== 0) {
          this.albumsSvc
            .getComments(this.selectedAlbum, this.selectedPhoto)
            .subscribe(res => (this.comments = res));
        }
  }
}
