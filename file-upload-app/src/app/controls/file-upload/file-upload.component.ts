import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FileService } from 'src/app/services/file-service/file.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit, OnDestroy {

  constructor(private fileService: FileService,
    private toastr: ToastrService) { }

  private uploadFile$: Subscription;
  private fileToUpload: File;

  @ViewChild('uploadForm') public uploadForm: NgForm;

  public fileSelected: boolean;
  public fileUploading: boolean;
  public errorHasOccured: boolean;
  public file: any;

  public handleFileInput(files: FileList): void {
    this.fileToUpload = files.item(0);
    this.fileSelected = true;
  }

  public onSubmit(): void {

    if (this.fileToUpload.type !== 'text/plain') {
      this.toastr.error('The selected file is not in .txt format.', 'Error');
      return;
    }

    this.fileUploading = true;

    this.uploadFile$ = this.fileService
      .uploadFile(this.fileToUpload)
      .subscribe(res => {
        this.fileUploading = false;
        this.fileService.newFileUploaded.emit();
        this.fileToUpload = null;
        this.fileSelected = false;
        this.uploadForm.reset();
        this.toastr.success('File added successfully.', 'Success');
      }, (res) => {
        this.fileUploading = false;
        this.errorHasOccured = true;
        this.fileToUpload = null;
        this.fileSelected = false;
        this.uploadForm.reset();

        const errorMessage = (res.status === 501) ?
          res.error : 'An error has occurred while adding the file.';

        this.toastr.error(errorMessage, 'Error');
      });
  }

  public ngOnInit(): void { }

  public ngOnDestroy(): void {
    if (Boolean(this.uploadFile$)) { this.uploadFile$.unsubscribe(); }
  }
}
