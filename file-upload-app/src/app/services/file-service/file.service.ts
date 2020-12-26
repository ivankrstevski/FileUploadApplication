import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private http: HttpClient) {
    this.baseApiAddress = `${environment.baseApiAddress}/file-upload`;
    this.newFileUploaded = new EventEmitter<void>();
  }

  private baseApiAddress: string;

  public newFileUploaded: EventEmitter<void>;

  public uploadFile(fileToUpload: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', fileToUpload);

    return this.http.post(`${this.baseApiAddress}/upload-file`, formData);
  }

  public getUploadedFiles(): Observable<any> {
    return this.http.get(`${this.baseApiAddress}/get-uploaded-files`);
  }

  public getFileContentItems(fileId: string): Observable<any> {
    return this.http.get(`${this.baseApiAddress}/get-file-content-items?fileid=${fileId}`, { params: { fileId } });
  }
}
