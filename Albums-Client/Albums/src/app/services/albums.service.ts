import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlbumsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAlbums(): Observable<any[]> {
    return this.http.get<any>(this.baseUrl + 'albums/');
  }

  getPhotos(albumId: number): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'albums/' + albumId + '/photos');
  }

  getComments(albumId: number, photoId: number): Observable<any[]> {
    return this.http.get<any[]>(
      this.baseUrl + 'albums/' + albumId + '/photos/' + photoId + '/comments'
    );
  }
}
