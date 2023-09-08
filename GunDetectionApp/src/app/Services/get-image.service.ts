import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
@Injectable({
  providedIn: 'root'
})
export class GetImageService {

  constructor(private http: HttpClient) { }


  DownloadImg(url: string) {
    fetch(url)
      .then(res => res.blob()) // Gets the response and returns it as a blob
      .then(blob => {
        // Here's where you get access to the blob
        // And you can use it for whatever you want
        // Like calling ref().put(blob)

        // Here, I use it to make an image appear on the page
        let objectURL = URL.createObjectURL(blob);
        console.log(blob);
        console.log(objectURL)
        let myImage = new Image();
        myImage.src = objectURL;

        this.downloadBlob("Picture" + Guid.create(), blob);


      });
  }



  private downloadBlob(fileName: string, blob: Blob): void {
    if (window.navigator.msSaveOrOpenBlob) {
      window.navigator.msSaveBlob(blob, fileName);
    } else {
      const anchor = window.document.createElement('a');
      anchor.href = window.URL.createObjectURL(blob);
      anchor.download = fileName;
      document.body.appendChild(anchor);
      anchor.click();
      document.body.removeChild(anchor);
      window.URL.revokeObjectURL(anchor.href);
    }
  }
}
