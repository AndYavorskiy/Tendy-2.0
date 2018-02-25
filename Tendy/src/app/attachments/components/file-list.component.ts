import _ = require('lodash');
import { NgxCarousel, NgxCarouselStore } from 'ngx-carousel';

import { Component, OnInit, Input } from '@angular/core';

import { FileModel } from '../models/file.model';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.scss']
})
export class FileListComponent implements OnInit {

  @Input()
  public ideaId: number;

  public files: FileModel[] = [
    { name: "some file1", extension: "txt" } as FileModel,
    { name: "some file2", extension: "png" } as FileModel,
    { name: "some file3", extension: "doc" } as FileModel,
    { name: "some file4", extension: "xls" } as FileModel,
    { name: "some file5", extension: "zip" } as FileModel,
    { name: "some file6", extension: "rar" } as FileModel,
    { name: "some file7", extension: "pdf" } as FileModel,
  ];

  public carouselBanner: NgxCarousel;

  constructor() { }

  public ngOnInit() {
    this.carouselBanner = {
      grid: { xs: 2, sm: 3, md: 4, lg: 5, all: 0 },
      speed: 400,
      point: {
        visible: true,
        pointStyles: `
        .ngxcarouselPoint {
          list-style-type: none;
          text-align: center;
          padding: 12px;
          margin: 0;
          white-space: nowrap;
          overflow: auto;
          box-sizing: border-box;
        }
        .ngxcarouselPoint li {
          display: inline-block;
          border-radius: 50%;
          border: 2px solid rgba(0, 0, 0, 0.55);
          padding: 4px;
          margin: 0 3px;
          transition-timing-function: cubic-bezier(.17, .67, .83, .67);
          transition: .4s;
        }
        .ngxcarouselPoint li.active {
            background: #6b6b6b;
            transform: scale(1.2);
        }
        .ngxcarousel {
          padding: 0 1em !important;
        }
        `
      },
      load: 4,
      touch: true
    }
  }

  public getFileIcon(file: FileModel) {

    if (_.includes(["png", "jpeg", "gif", "jpg"], file.extension)) {
      return "fa-file-image pink";
    }
    else if (_.includes(["doc", "docx"], file.extension)) {
      return "fa-file-word dobger-blue";
    }
    else if (_.includes(["xls"], file.extension)) {
      return "fa-file-excel excel";
    }
    else if (_.includes(["mp4"], file.extension)) {
      return "fa-file-video coral";
    }
    else if (_.includes(["cs", "ts", "css", "html", "js"], file.extension)) {
      return "fa-file-code dark";
    }
    else if (_.includes(["pdf"], file.extension)) {
      return "fa-file-pdf danger";
    }
    else if (_.includes(["zip", "7zip"], file.extension)) {
      return "fa-file-archive dart-green";
    }
    else {
      return "fa-file-alt violet";
    }
  }
}
