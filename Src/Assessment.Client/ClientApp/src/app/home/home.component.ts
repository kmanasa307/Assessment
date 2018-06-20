import { Component, OnInit } from '@angular/core';
import { Board } from '../models/board';
import { PostIt } from '../models/post-it';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  boards: Board[];
  message: string;
  boardCounter: number;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBoards();

    this.boardCounter = this.boards[this.boards.length - 1].id;

    console.log('last id : ' + this.boardCounter);
  }

  getBoards() {
    this.http.get<Board[]>('/api/boards').subscribe(data => {
      this.boards = data;
    });
  }

  deleteBoard(boardId: number) {
    this.http.delete('/api/boards/' + boardId).subscribe(
      data => {
        // refresh the list
        this.getBoards();
        return true;
      },
      error => {
        console.error("Error deleting board!");        
      }
    );
  }

  addBoard() {
    //get max id
    let id = 1;
    if (this.boards.length > 0) {
      let maximum = Math.max.apply(Math, this.boards.map(function (b) { return b.id; }));
      id = maximum + 1;
    }
    let newBoard = {
      "Id": id, "Name": "Board # " + id, "CreatedAt": new Date()
    }
    
    this.http.post('/api/boards', newBoard).subscribe(
      data => {
        // refresh the list
        this.getBoards();
        return true;
      },
      error => {
        console.error("Error adding board!");
      }
    );
  }

}
