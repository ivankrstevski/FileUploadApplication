import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { FileService } from 'src/app/services/file-service/file.service';

@Component({
  selector: 'app-uploaded-files-list',
  templateUrl: './uploaded-files-list.component.html',
  styleUrls: ['./uploaded-files-list.component.css']
})
export class UploadedFilesListComponent implements OnInit, OnDestroy {

  constructor(private fileService: FileService) { }

  private getUploadedFiles$: Subscription;
  private newFileUploaded$: Subscription;

  public loadingFiles: boolean;
  public errorHasOccured: boolean;
  public updatedFiles: any;

  private loadUploadedFiles(): void {

    this.loadingFiles = true;
    this.errorHasOccured = false;

    this.getUploadedFiles$ = this.fileService
      .getUploadedFiles()
      .subscribe(res => {
        this.updatedFiles = res;
        this.loadingFiles = false;
      }, () => {
        this.loadingFiles = false;
        this.errorHasOccured = true;
      });
  }

  public ngOnInit(): void {

    this.loadUploadedFiles();

    this.newFileUploaded$ = this.fileService
      .newFileUploaded.subscribe(() => this.loadUploadedFiles());
  }

  public ngOnDestroy(): void {
    if (Boolean(this.getUploadedFiles$)) { this.getUploadedFiles$.unsubscribe(); }
    if (Boolean(this.newFileUploaded$)) { this.newFileUploaded$.unsubscribe(); }
  }
}
