import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SpotifyService {

  constructor(private http: HttpClient) { }

  getQuery(query: string) {
    const url = `https://api.spotify.com/v1/${query}`;

    const headers = new HttpHeaders({
      'Authorization': 'Bearer BQC7m7jBVxXUq8YGDOdYD2eZrEx49IDZEIvZ3O6THdJEuiN_o2EjHnc83n3Gicp0vo55NMlB8uO3WubGGlI'
    });

    return this.http.get(url, { headers});
  }

  getNewReleases() {
    return this.getQuery('browse/new-releases').pipe( map(data => data['albums'].items));
  }

  getArtistas(termino: string) {
    return this.getQuery(`search?q=${termino}&type=artist`).pipe( map(data => data['artists'].items));
  }

  getArtista(id: string) {
    return this.getQuery(`artists/${id}`);
  }

  getTopTracks(id: string) {
    return this.getQuery(`artists/${id}/top-tracks?country=us`)
    .pipe( map(data => data['tracks']));
  }
}
