import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { CommentView } from '../_models/CommentView';
import { Comments } from '../_models/Comments';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }
  private _commentMessageSorce$ = new Subject<void>();
  get refreshNeeded$() {
    return this._commentMessageSorce$;
  }
  getComment(id: number) {
    return this.http.get<CommentView[]>(`/api/Comment/${id}`);
  }
  addComment(comment: Comments) {
    return this.http.post<Comment>("/api/Comment", comment)
      .pipe(
        tap(() => {
          this._commentMessageSorce$.next();
        })
      )
  }
}
