using System;
using System.Text;
using System.Windows.Forms;

namespace SoftPhoneLogDetail
{
    public partial class Form1 : Form
    {
        // クライアント処理
        private const string CLIENT_START = "画面ロード - [Start]";
        private const string CLIENT_END = "画面ロード - [End]";

        // サーバー処理
        private const string SERVER_START = "サーバ処理 - [Start]";
        private const string SERVER_END = "サーバ処理 - [End]";

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 平均時間計算
        /// </summary>
        private void AvgTimeCalc()
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                object key1 = dataGridView1.Rows[i].Cells[2].Value;
                object key2 = dataGridView1.Rows[i].Cells[3].Value;

                if (key1 != null && key2 != null)
                {
                    // 平均計算対象
                    TimeSpan totalTs = new TimeSpan(0,
                                               Convert.ToInt32(key2.ToString().Substring(0, 2)),
                                               Convert.ToInt32(key2.ToString().Substring(3, 2)),
                                               Convert.ToInt32(key2.ToString().Substring(6, 2)),
                                               Convert.ToInt32(key2.ToString().Substring(9, 3)));
                    dataGridView1.Rows[i].Cells[6].Value =
                        TimeSpan.FromSeconds(totalTs.TotalSeconds / Convert.ToInt32(key1.ToString())).ToString().Substring(0, 12);

                    // １秒未満　　：　無し
                    // １秒～２秒　：　無し
                    // ２秒～３秒　：　ＢＬＵＥ
                    // ３秒～４秒　：　ＯＲＡＮＧＥ
                    // ４秒～　　　：　ＲＥＤ
                    int resultInt =
                        Convert.ToInt32(totalTs.TotalSeconds / Convert.ToInt32(key1.ToString()));

                    switch (resultInt)
                    {
                        case 0:
                        case 1:
                            /* 通常モード */
                            dataGridView1.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Transparent;
                            break;

                        case 2:
                            /* 警告 */
                            dataGridView1.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Yellow;
                            break;

                        case 3:
                            /* 注意 */
                            dataGridView1.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Orange;
                            break;

                        default:
                            /* 危険 */
                            dataGridView1.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Red;
                            break;
                    }
                }

                object key3 = dataGridView1.Rows[i].Cells[4].Value;
                object key4 = dataGridView1.Rows[i].Cells[5].Value;

                if (key3 != null && key4 != null)
                {
                    // 平均計算対象
                    TimeSpan totalTs = new TimeSpan(0,
                                               Convert.ToInt32(key4.ToString().Substring(0, 2)),
                                               Convert.ToInt32(key4.ToString().Substring(3, 2)),
                                               Convert.ToInt32(key4.ToString().Substring(6, 2)),
                                               Convert.ToInt32(key4.ToString().Substring(9, 3)));
                    dataGridView1.Rows[i].Cells[7].Value =
                        TimeSpan.FromSeconds(totalTs.TotalSeconds / Convert.ToInt32(key3.ToString())).ToString().Substring(0, 12);

                    // １秒未満　　：　無し
                    // １秒～２秒　：　無し
                    // ２秒～３秒　：　ＢＬＵＥ
                    // ３秒～４秒　：　ＯＲＡＮＧＥ
                    // ４秒～　　　：　ＲＥＤ
                    int resultInt =
                        Convert.ToInt32(totalTs.TotalSeconds / Convert.ToInt32(key3.ToString()));

                    switch (resultInt)
                    {
                        case 0:
                        case 1:
                            /* 通常モード */
                            dataGridView1.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.Transparent;
                            break;

                        case 2:
                            /* 警告 */
                            dataGridView1.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.Yellow;
                            break;

                        case 3:
                            /* 注意 */
                            dataGridView1.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.Orange;
                            break;

                        default:
                            /* 危険 */
                            dataGridView1.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// ログ内容を解析する
        /// </summary>
        private void ReadFileLoad()
        {
            string HoldTime_Start = string.Empty;
            string HoldTime_End = string.Empty;
            int idx = 0;

            // ファイル存在確認
            if (!System.IO.File.Exists(txtReadFile.Text))
            {
                MessageBox.Show("'" + txtReadFile.Text + "'は存在しません。",
                                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 全体時間集計用
            TimeSpan totalTs = new TimeSpan(0, 0, 0, 0, 0);

            // 指定ファイルを読み込む
            System.IO.StreamReader sr =
                new System.IO.StreamReader(txtReadFile.Text,
                Encoding.Default);

            while (sr.Peek() > -1)
            {
                string tarRowData = sr.ReadLine();

                // ■■■■■■■■■■■■■■■
                // ■■■ クライアント処理 ■■■
                // ■■■■■■■■■■■■■■■
                if (tarRowData.IndexOf(CLIENT_START) >= 0)
                {
                    HoldTime_Start = tarRowData.Substring(0, 23);
                }
                else if (tarRowData.IndexOf(CLIENT_END) >= 0 && string.IsNullOrEmpty(HoldTime_Start))
                {
                    // データが前後連携されてないのでデータから削除
                    HoldTime_Start = string.Empty;
                    HoldTime_End = string.Empty;
                }
                else if (tarRowData.IndexOf(CLIENT_END) >= 0)
                {
                    HoldTime_End = tarRowData.Substring(0, 23);

                    // 行情報特定
                    idx = this.FindIdx(tarRowData.Substring(tarRowData.IndexOf("|RAC") + 1, 14));

                    // 時間計算開始
                    DateTime startDateTime = Convert.ToDateTime(HoldTime_Start.Replace(",", "."));
                    DateTime endDateTime = Convert.ToDateTime(HoldTime_End.Replace(",", "."));
                    TimeSpan ts = endDateTime - startDateTime;
                    if (ts.ToString().Length < 9)
                    {
                        string targetData = ts.ToString();
                        ts = new TimeSpan(0,
                             Convert.ToInt32(targetData.Substring(0, 2)),
                             Convert.ToInt32(targetData.Substring(3, 2)),
                             Convert.ToInt32(targetData.Substring(6, 2)),
                             001);
                    }

                    // 時間集計
                    totalTs += ts;

                    // 起動結果カウンター
                    if (dataGridView1.Rows[idx].Cells[2].Value != null &&
                        !string.IsNullOrEmpty(dataGridView1.Rows[idx].Cells[2].Value.ToString()))
                    {
                        // 累計
                        dataGridView1.Rows[idx].Cells[2].Value = (Convert.ToInt32(dataGridView1.Rows[idx].Cells[2].Value) + 1).ToString();
                    }
                    else
                    {
                        // 新規
                        dataGridView1.Rows[idx].Cells[2].Value = "1";
                    }

                    // 時差計算結果反映
                    if (dataGridView1.Rows[idx].Cells[3].Value != null &&
                        !string.IsNullOrEmpty(dataGridView1.Rows[idx].Cells[3].Value.ToString()))
                    {
                        // データ累積
                        string targetData = dataGridView1.Rows[idx].Cells[3].Value.ToString();
                        TimeSpan tt;
                        if (targetData.Length > 9)
                        {
                            tt = new TimeSpan(0,
                                              Convert.ToInt32(targetData.Substring(0, 2)),
                                              Convert.ToInt32(targetData.Substring(3, 2)),
                                              Convert.ToInt32(targetData.Substring(6, 2)),
                                              Convert.ToInt32(targetData.Substring(9, 3)));
                        }
                        else
                        {
                            tt = new TimeSpan(0,
                                              Convert.ToInt32(targetData.Substring(0, 2)),
                                              Convert.ToInt32(targetData.Substring(3, 2)),
                                              Convert.ToInt32(targetData.Substring(6, 2)),
                                              001);
                        }
                        if ((tt + ts).ToString().Length < 13)
                        {
                            // 合算した結果が .000になることを考慮
                            dataGridView1.Rows[idx].Cells[3].Value = (tt + ts).ToString() + ".001";
                        }
                        else
                        {
                            dataGridView1.Rows[idx].Cells[3].Value = (tt + ts).ToString().Substring(0, 12);
                        }
                    }
                    else
                    {
                        // データ導入
                        dataGridView1.Rows[idx].Cells[3].Value = ts.ToString().Substring(0, 12);
                    }

                    // 保持情報初期化
                    HoldTime_Start = string.Empty;
                    HoldTime_End = string.Empty;
                }

                // ■■■■■■■■■■■■
                // ■■■ サーバ処理 ■■■
                // ■■■■■■■■■■■■
                if (tarRowData.IndexOf(SERVER_START) >= 0)
                {
                    HoldTime_Start = tarRowData.Substring(0, 23);
                }
                else if (tarRowData.IndexOf(SERVER_END) >= 0 && string.IsNullOrEmpty(HoldTime_Start))
                {
                    // データが前後連携されてないのでデータから削除
                    HoldTime_Start = string.Empty;
                    HoldTime_End = string.Empty;
                }
                else if (tarRowData.IndexOf(SERVER_END) >= 0)
                {
                    HoldTime_End = tarRowData.Substring(0, 23);

                    // 行情報特定
                    idx = this.FindIdx(tarRowData.Substring(tarRowData.IndexOf("|RAC") + 1, 14));

                    // 時間計算開始
                    DateTime startDateTime = Convert.ToDateTime(HoldTime_Start.Replace(",", "."));
                    DateTime endDateTime = Convert.ToDateTime(HoldTime_End.Replace(",", "."));
                    TimeSpan ts = endDateTime - startDateTime;
                    if (ts.ToString().Length < 9)
                    {
                        string targetData = ts.ToString();
                        ts = new TimeSpan(0,
                             Convert.ToInt32(targetData.Substring(0, 2)),
                             Convert.ToInt32(targetData.Substring(3, 2)),
                             Convert.ToInt32(targetData.Substring(6, 2)),
                             001);
                    }

                    // 時間集計
                    totalTs += ts;

                    // 起動結果カウンター
                    if (dataGridView1.Rows[idx].Cells[4].Value != null &&
                        !string.IsNullOrEmpty(dataGridView1.Rows[idx].Cells[4].Value.ToString()))
                    {
                        // 累計
                        dataGridView1.Rows[idx].Cells[4].Value = (Convert.ToInt32(dataGridView1.Rows[idx].Cells[4].Value) + 1).ToString();
                    }
                    else
                    {
                        // 新規
                        dataGridView1.Rows[idx].Cells[4].Value = "1";
                    }

                    // 時差計算結果反映
                    if (dataGridView1.Rows[idx].Cells[5].Value != null &&
                        !string.IsNullOrEmpty(dataGridView1.Rows[idx].Cells[5].Value.ToString()))
                    {
                        // データ累積
                        string targetData = dataGridView1.Rows[idx].Cells[5].Value.ToString();
                        TimeSpan tt;
                        if (targetData.Length > 9)
                        {
                            tt = new TimeSpan(0,
                                              Convert.ToInt32(targetData.Substring(0, 2)),
                                              Convert.ToInt32(targetData.Substring(3, 2)),
                                              Convert.ToInt32(targetData.Substring(6, 2)),
                                              Convert.ToInt32(targetData.Substring(9, 3)));
                        }
                        else
                        {
                            tt = new TimeSpan(0,
                                              Convert.ToInt32(targetData.Substring(0, 2)),
                                              Convert.ToInt32(targetData.Substring(3, 2)),
                                              Convert.ToInt32(targetData.Substring(6, 2)),
                                              001);
                        }

                        if ((tt + ts).ToString().Length < 13)
                        {
                            // 合算した結果が .000になることを考慮
                            dataGridView1.Rows[idx].Cells[5].Value = (tt + ts).ToString() + ".001";
                        }
                        else
                        {
                            dataGridView1.Rows[idx].Cells[5].Value = (tt + ts).ToString().Substring(0, 12);
                        }
                    }
                    else
                    {
                        // データ導入
                        dataGridView1.Rows[idx].Cells[5].Value = ts.ToString().Substring(0, 12);
                    }

                    // 保持情報初期化
                    HoldTime_Start = string.Empty;
                    HoldTime_End = string.Empty;
                }
            }
        }

        /// <summary>
        /// 分析開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            // ログ内容を解析する
            this.ReadFileLoad();

            // 全体平均時間計算
            this.AvgTimeCalc();
        }

        /// <summary>
        /// 画面IDを利用して、グリッドの列を特定
        /// </summary>
        /// <param name="dispID">画面ＩＤ</param>
        /// <returns>画面ＩＤが属しているインデックス</returns>
        private int FindIdx(string dispID)
        {
            // グリッドのローカウント分ループ
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().IndexOf(dispID) >= 0)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// ファイル選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK &&
                !string.IsNullOrEmpty(ofd.FileName))
            {
                // 選択されたファイル名を入れ込む
                txtReadFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// フォルダ選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            //fbd.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK &&
                !string.IsNullOrEmpty(fbd.SelectedPath))
            {
                // 指定されたフォルダ
                txtReadFolder.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// フォルダ内部のファイル全体に対する分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            // 全体初期化
            this.InitDisp();

            // 指定フォルダからphoneログ全体対象にリスト作成
            string[] files = System.IO.Directory.GetFiles(
                txtReadFolder.Text, "customerPerformance*", System.IO.SearchOption.AllDirectories);

            // カウンタ初期化
            int idx = 0;
            TimeSpan totalTs = new TimeSpan(0, 0, 0, 0, 0);

            // ファイル数分のループ処理
            foreach (var file in files)
            {
                txtReadFile.Text = file.ToString();
                this.ReadFileLoad();
            }

            // 全体平均時間計算
            this.AvgTimeCalc();
        }

        /// <summary>
        /// 画面全体クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.InitDisp();
        }

        /// <summary>
        /// 初期データ導入
        /// </summary>
        private void InitDisp()
        {
            int idx = 0;
            this.dataGridView1.Rows.Clear();

            #region 画面名

            // 画面名
            string[] NAME =
            {
                "メインメニュー",
                "アカウント管理",
                "アカウント詳細",
                "CSVダウンロード",
                "ワークフローマスタ管理",
                "ワークフローマスタ詳細",
                "承認ルート管理",
                "承認ルート詳細",
                "承認グループ管理",
                "承認グループ詳細",
                "管理者メニュー",
                "権限グループマスタ管理",
                "権限グループマスタ詳細",
                "着信メッセージ管理",
                "着信メッセージ詳細",
                "内線番号管理",
                "内線番号詳細",
                "コードマスタ管理",
                "コードマスタ詳細",
                "資料マスタ管理",
                "資料マスタ詳細",
                "コンタクトワークフロー種別マスタ管理",
                "コンタクトワークフロー種別マスタ詳細",
                "HP連携取込管理",
                "受付内容訂正",
                "申送情報一括登録",
                "console_racuos",
                "console_racuos",
                "console_racuos",
                "console_racuos",
                "console_racuos",
                "console_racuos",
                "会員情報検索",
                "本人確認",
                "会員詳細情報",
                "会員詳細情報：申送情報",
                "会員詳細情報：申送情報登録",
                "会員詳細情報：PINKカードサービス",
                "会員詳細情報：金黒カードサービス",
                "会員詳細情報：入金内訳",
                "会員詳細情報：入金受付詳細",
                "会員詳細情報：利用枠変更履歴",
                "会員詳細情報：メール詳細",
                "会員詳細情報：対話履歴",
                "会員詳細情報：顧客情報",
                "会員詳細情報：契約情報(カード)",
                "会員詳細情報：契約情報（個品割賦）",
                "会員詳細情報：契約情報(融資）",
                "会員詳細情報：契約情報（リース）",
                "会員詳細情報：契約情報（タクシー）",
                "会員詳細情報：契約情報(提携保証）",
                "会員詳細情報：請求明細",
                "会員詳細情報：入金",
                "会員詳細情報：売上",
                "会員詳細情報：オーソリ",
                "会員詳細情報：e-NAVI1",
                "会員詳細情報：e-NAVI2",
                "会員詳細情報：キャンペーン",
                "会員詳細情報：楽天ID",
                "会員詳細情報：Vプリカ",
                "会員詳細情報：Edy",
                "会員詳細情報：オートローン",
                "会員詳細情報：利用枠",
                "会員詳細情報：書面発送",
                "会員詳細情報：メール",
                "会員詳細情報：口座情報",
                "会員詳細情報：キャンセル",
                "受架電メニュー",
                "発信確認",
                "内線番号設定",
                "手動メール配信",
                "Voistore再生",
                "コンタクト履歴検索",
                "コンタクト履歴詳細",
                "入金試算照会",
                "充当指定試算",
                "お客様の声検索",
                "お客様の声対応一覧",
                "お客様の声詳細",
                "お客様の声詳細：受付・加盟店等調査",
                "お客様の声詳細：最終判定",
                "お客様の声詳細：処理履歴",
                "お客様の声詳細：処理履歴",
                "お客様の声詳細：履歴登録",
                "関連法令",
                "ワークフロー検索",
                "ワークフロー詳細",
                "ワークフロー詳細：パターン０１",
                "ワークフロー詳細：パターン０２",
                "ワークフロー詳細：パターン０３",
                "ワークフロー詳細：パターン０４",
                "ワークフロー詳細：パターン０５",
                "ワークフロー詳細：パターン０６",
                "ワークフロー詳細：パターン０７",
                "ワークフロー詳細：パターン０８",
                "ワークフロー詳細：パターン０９",
                "ワークフロー詳細：パターン１０",
                "ワークフロー詳細：パターン１１",
                "ワークフロー詳細：パターン１２",
                "ワークフロー詳細：パターン１３",
                "ワークフロー詳細：パターン１４",
                "ワークフロー選択",
                "ワークフロー確認",
                "ワークフロー承認状況",
                "登録情報変更",
                "脱会受付",
                "紛失・盗難登録",
                "資料請求受付",
                "住所コード一覧検索",
                "ホスト属性変更",
                "分類コード一覧（職種）",
                "申請書検索",
                "オペレータ処理履歴検索",
                "返済変更受付（コンタクト）",
                "返済変更受付（緩和）",
                "返済変更承認（コンタクト）",
                "返済変更承認（緩和）",
                "返済変更シミュレーション",
                "承認者返済変更受付一覧",
                "返済変更処理実績照会",
                "履歴記載文言",
                "入金履歴",
                "返済変更履歴",
            };

            #endregion 画面名

            #region 画面ID

            // 画面ＩＤ
            string[] ID =
            {
                "00001_00000",
                "00002_00000",
                "00101_00000",
                "00003_00000",
                "01001_00000",
                "01101_00000",
                "01002_00000",
                "01102_00000",
                "01003_00000",
                "01103_00000",
                "00004_00000",
                "00005_00000",
                "00102_00000",
                "02001_00000",
                "02101_00000",
                "02002_00000",
                "02102_00000",
                "00006_00000",
                "00103_00000",
                "01004_00000",
                "01104_00000",
                "01005_00000",
                "01105_00000",
                "01006_00000",
                "01106_00000",
                "01007_00000",
                "03001_00000",
                "03002_00000",
                "03003_00000",
                "03004_00000",
                "03005_00000",
                "03006_00000",
                "10001_00000",
                "10003_00000",
                "10002_00000",
                "10102_00000",
                "10102_00700",
                "10102_00100",
                "10102_00200",
                "10102_00300",
                "10102_00400",
                "10102_00500",
                "10102_00600",
                "10202_01000",
                "10202_02000",
                "10202_03000",
                "10202_03100",
                "10202_03200",
                "10202_03300",
                "10202_03400",
                "10202_03500",
                "10202_04000",
                "10202_05000",
                "10202_06000",
                "10202_07000",
                "10202_08000",
                "10202_08100",
                "10202_09000",
                "10202_10000",
                "10202_11000",
                "10202_12000",
                "10202_13000",
                "10202_14000",
                "10202_15000",
                "10202_16000",
                "10202_17000",
                "10202_18000",
                "10004_00000",
                "10104_00000",
                "10204_00000",
                "11001_00000",
                "11002_00000",
                "10005_00000",
                "10105_00000",
                "10006_00000",
                "10106_00000",
                "20001_00000",
                "20001_00100",
                "20002_00000",
                "20202_01000",
                "20202_02000",
                "20202_03000",
                "20202_03000",
                "20102_00000",
                "20101_00000",
                "30001_00000",
                "30002_00000",
                "30002_01000",
                "30002_02000",
                "30002_03000",
                "30002_04000",
                "30002_05000",
                "30002_06000",
                "30002_07000",
                "30002_08000",
                "30002_09000",
                "30002_10000",
                "30002_11000",
                "30002_12000",
                "30002_13000",
                "30002_14000",
                "30101_00000",
                "30102_00000",
                "30103_00000",
                "30003_00000",
                "30004_00000",
                "30005_00000",
                "30006_00000",
                "30104_00000",
                "30105_00000",
                "30106_00000",
                "30007_00000",
                "30008_00000",
                "40001_00000",
                "40002_00000",
                "40101_00000",
                "40102_00000",
                "40201_00000",
                "40301_00000",
                "40401_00000",
                "40501_00000",
                "40601_00000",
                "40701_00000",
            };

            #endregion 画面ID

            foreach (string key in ID)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[idx].Cells[0].Value = "RAC" + ID[idx];
                dataGridView1.Rows[idx].Cells[1].Value = NAME[idx];
                idx++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitDisp();
        }
    }
}
