import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { Subscription } from 'rxjs';
import { FileService } from 'src/app/services/file-service/file.service';

@Component({
  selector: 'app-file-content',
  templateUrl: './file-content.component.html',
  styleUrls: ['./file-content.component.css']
})
export class FileContentComponent implements OnInit, OnDestroy {

  constructor(private route: ActivatedRoute,
    private fileService: FileService) {
    this.barChartLabels = new Array<Label>();
    this.backgroundColors = new Array<string>();
    this.numbers = new Array<number>();
    this.barChartData = Array<ChartDataSets>();
  }

  private getRoute$: Subscription;
  private getFileContentItems$: Subscription;
  private fileId: string;

  public barChartLabels: Array<Label>;
  public backgroundColors: Array<string>;
  public numbers: Array<number>;
  public barChartData: Array<ChartDataSets>;
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public chartLoading: boolean;
  public errorHasOccured: boolean;

  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true
        }
      }]
    }
  };

  private getContentItems(): void {
    this.chartLoading = true;
    this.errorHasOccured = false;

    this.getFileContentItems$ = this.fileService
      .getFileContentItems(this.fileId)
      .subscribe(result => {
        result.forEach(item => {
          this.barChartLabels.push(item.label);
          this.backgroundColors.push(item.color);
          this.numbers.push(item.number);
        });

        this.barChartData.push({
          data: this.numbers,
          backgroundColor: this.backgroundColors,
          label: 'File Content Items'
        });

        this.chartLoading = false;
      }, () => {
        this.errorHasOccured = true;
        this.chartLoading = false;
      });
  }

  public ngOnInit(): void {
    this.getRoute$ = this.route.
      params.subscribe(params => {
        this.fileId = params.id;
        this.getContentItems();
      });
  }

  public ngOnDestroy(): void {
    if (Boolean(this.getRoute$)) { this.getRoute$.unsubscribe(); }
    if (Boolean(this.getFileContentItems$)) { this.getFileContentItems$.unsubscribe(); }
  }
}
